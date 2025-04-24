import { ActivityStatus } from "../enum/ActivityStatus";

export type Activity = {
  id: number;
  title: string;
  description: string;
  status: ActivityStatus;
};
