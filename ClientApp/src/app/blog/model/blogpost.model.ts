export interface BlogModel {
    id:number;
    username:string;
    datecreate:Date;
    text:string;
    state: State;
}

export enum State {
    none, added, updated, deleted
  }