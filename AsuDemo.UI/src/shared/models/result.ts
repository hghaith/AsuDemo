export class EmptyResult {
  isSuccess: boolean = true;
  errors: Array<string> = new Array<string>();
}

export class Result<T> extends EmptyResult {
  data: T = null as any;
}
