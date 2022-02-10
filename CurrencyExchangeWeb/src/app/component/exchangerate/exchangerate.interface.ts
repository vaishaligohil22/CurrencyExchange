
export interface IExchangeRate {
  success: boolean;
  historical: boolean;
  timestamp: string;
  base: string;
  date: Date;
  rates: { [key: string]: number; };
}

