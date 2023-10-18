import { IAccount } from './account';

export interface IEmployee {
  id: number;
  name: string;
  surname: string;
  dateOfEntry: string;
  positionId: number;
  account: IAccount;
}
