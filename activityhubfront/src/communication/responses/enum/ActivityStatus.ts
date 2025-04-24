export enum ActivityStatus {
  Describing = 1,
  Doing = 2,
  Done = 3,
}

export const ActivityStatusLabel = new Map<number, string>([
  [ActivityStatus.Describing, "Describing"],
  [ActivityStatus.Doing, "Doing"],
  [ActivityStatus.Done, "Done"],
]);
