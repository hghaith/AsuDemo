using AsuDemo.Application.CourseService;
using AsuDemo.Application.DepartmentCourseService;
using AsuDemo.Application.DepartmentService;
using AsuDemo.Domain.Context;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Mapping Register is here because lack of time (they should be in Application)
var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;


typeAdapterConfig.NewConfig<Department, DepartmentDto>()
                .Map(d => d.DepartmentCourses, s => s.DepartmentCourses != null && s.DepartmentCourses.Count != 0 ?
                s.DepartmentCourses.Select(x => x.CourseId) : null);

typeAdapterConfig.NewConfig<DepartmentDto, Department>()
    .Map(d => d.DepartmentCourses, s => s.DepartmentCourses != null ? s.DepartmentCourses.Select(courseId => new DepartmentCourse { CourseId = courseId }) : null);

typeAdapterConfig.NewConfig<Course, CourseDto>()
                .Map(d => d.DepartmentCourses, s => s.DepartmentCourses != null && s.DepartmentCourses.Count != 0 ?
                s.DepartmentCourses.Select(x => x.DepartmentId) : null);

typeAdapterConfig.NewConfig<CourseDto, Course>()
    .Map(d => d.DepartmentCourses, s => s.DepartmentCourses != null ? s.DepartmentCourses.Select(departmentId => new DepartmentCourse { DepartmentId = departmentId }) : null);

typeAdapterConfig.Default.IgnoreNullValues(true);

builder.Services.AddSingleton(typeAdapterConfig);
#endregion


// Register Services Manual Instead Of Dynamically for simplicity :)
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IDepartmentCourseService, DepartmentCourseService>();
builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddDbContext<AsuDemoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
