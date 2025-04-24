"use client";

import { ActivityCard } from "./activity-card";
import { getActivitiesResponse } from "@/http/get-activities";
import { Badge } from "@/components/ui/badge";

interface KanbanColumnProps {
  column: getActivitiesResponse;
}

export function KanbanColumn({ column }: KanbanColumnProps) {
  return (
    <div className="space-y-4 bg-secondary p-4 rounded-lg border border-zinc-900">
      <div className="flex items-center gap-2">
        <h2 className="font-semibold text-sm uppercase tracking-wide text-white">
          {column.title}
        </h2>
        <Badge
          variant="secondary"
          className="rounded-full text-white bg-purple-500"
        >
          {column.listActivities.length}
        </Badge>
      </div>

      {column.listActivities.length === 0 ? (
        <div className="min-h-[200px] rounded-lg border border-dashed border-gray-200 dark:border-gray-800 flex items-center justify-center">
          <p className="text-muted-foreground text-sm">Drop tasks here</p>
        </div>
      ) : (
        <div className="space-y-3">
          {column.listActivities.map((activity) => (
            <ActivityCard key={activity.id} activity={activity} />
          ))}
        </div>
      )}
    </div>
  );
}
