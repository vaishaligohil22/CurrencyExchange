export interface Item {
  id: number;
  currFrom: string;
  currTo: string;
  rate: number;
  date: Date;
}

export interface IChart {
  items: Item[];
  totalHits: number;
}
