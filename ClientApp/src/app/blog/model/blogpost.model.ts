export interface BlogModel {
    id:number;
    username:string;
    datecreated:string;
    text:string;
    state: State;
}

export enum State {
    none, added, updated, deleted
  }