export interface LogEntry {
  id: number;
  objectName: string;
  eventName: string;
  eventData: string;
}

export interface Action {
  id: number;
  name: string;
}
