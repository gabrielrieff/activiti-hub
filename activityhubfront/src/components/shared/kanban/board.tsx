"use client";

import { useEffect, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getActivities, getActivitiesResponse } from "@/http/get-activities";
import { Button } from "@/components/ui/button";
import Link from "next/link";
import { Clock, Plus } from "lucide-react";
import {
  KanbanBadge,
  KanbanCard,
  KanbanCardContent,
  KanbanCardFooter,
  KanbanCardFooterBadge,
  KanbanCardHeader,
  KanbanCardTitle,
  KanbanColumn,
  KanbanColumnHeader,
  KanbanTitle,
} from "../kanban";
import {
  ActivityStatus,
  ActivityStatusLabel,
} from "@/communication/responses/enum/ActivityStatus";

export function KanbanBoard() {
  const { data, isLoading } = useQuery({
    queryKey: ["activities"],
    queryFn: () => getActivities(),
  });

  const [columns, setColumns] = useState<getActivitiesResponse[]>([]);

  const ColorBadge = (status: ActivityStatus) => {
    switch (status) {
      case ActivityStatus.Describing:
        return "bg-orange-100 text-orange-700 dark:bg-orange-900/30";
      case ActivityStatus.Doing:
        return "bg-green-100 text-green-700 dark:bg-green-900/30 dark:text-green-400";
      case ActivityStatus.Done:
        return "bg-cyan-100 text-cyan-700 dark:bg-cyan-900/30 dark:text-cyan-400";
    }
  };

  useEffect(() => {
    if (data) {
      setColumns(data);
    }
  }, [data]);

  // const moveTask = (
  //   activityId: number,
  //   sourceColumnId: string,
  //   targetColumnId: string,
  //   sourceIndex?: number,
  //   targetIndex?: number
  // ) => {
  //   setColumns((prevColumns) => {
  //     const sourceColumn = prevColumns.find((col) => col.id === sourceColumnId);
  //     const targetColumn = prevColumns.find((col) => col.id === targetColumnId);

  //     if (!sourceColumn || !targetColumn) return prevColumns;

  //     const taskToMove = sourceColumn.listActivities.find(
  //       (activity) => activity.id === activityId
  //     );
  //     if (!taskToMove) return prevColumns;

  //     const updatedSourceTasks = sourceColumn.listActivities.filter(
  //       (activity) => activity.id !== activityId
  //     );

  //     if (
  //       sourceColumnId !== targetColumnId &&
  //       sourceIndex !== undefined &&
  //       targetIndex !== undefined
  //     ) {
  //       updatedSourceTasks.splice(targetIndex, 0, taskToMove);

  //       return prevColumns.map((col) => {
  //         if (col.id === sourceColumnId) {
  //           return { ...col, listActivities: updatedSourceTasks };
  //         }
  //         return col;
  //       });
  //     }

  //     const updatedTargetTasks = [...targetColumn.listActivities];

  //     if (targetIndex !== undefined) {
  //       updatedTargetTasks.splice(targetIndex, 0, taskToMove);
  //     } else {
  //       updatedTargetTasks.push(taskToMove);
  //     }

  //     return prevColumns.map((col) => {
  //       if (col.id === sourceColumnId) {
  //         return { ...col, listActivities: updatedSourceTasks };
  //       }
  //       if (col.id === targetColumnId) {
  //         return { ...col, listActivities: updatedTargetTasks };
  //       }
  //       return col;
  //     });
  //   });
  //};

  return (
    <div className="container">
      <div className="mb-6 flex items-center justify-between text-white">
        <div>
          <h1 className="text-2xl font-bold tracking-tight">Kanban Board</h1>
          <p className="">Manage and track your activities</p>
        </div>
        <div className="flex items-center gap-2">
          <Button asChild>
            <Link href="/activity/create">
              <Plus className="h-4 w-4" />
              Criar
            </Link>
          </Button>
        </div>
      </div>
      <div className="grid grid-cols-1 gap-6 md:grid-cols-3">
        {isLoading ? (
          <div className="flex items-center space-x-4">carregando...</div>
        ) : (
          columns.map((column) => (
            <KanbanColumn key={column.id}>
              <KanbanColumnHeader>
                <KanbanTitle>{column.title}</KanbanTitle>
                <KanbanBadge>{column.listActivities.length}</KanbanBadge>
              </KanbanColumnHeader>
              {column.listActivities.length === 0 ? (
                <div className="min-h-[200px] rounded-lg border border-dashed border-gray-200 dark:border-gray-800 flex items-center justify-center">
                  <p className="text-muted-foreground text-sm">
                    Drop tasks here
                  </p>
                </div>
              ) : (
                <div className="space-y-3">
                  {column.listActivities.map((activity) => (
                    // <ActivityCard key={activity.id} activity={activity} />
                    <KanbanCard
                      href={`activity/edit/${activity.id}`}
                      key={activity.id}
                    >
                      <KanbanCardHeader
                        id={activity.id.toString()}
                        href={`activity/edit/${activity.id}`}
                      >
                        <KanbanCardTitle>{activity.title}</KanbanCardTitle>
                      </KanbanCardHeader>
                      <KanbanCardContent>
                        {activity.description}
                      </KanbanCardContent>
                      <KanbanCardFooter>
                        <KanbanCardFooterBadge
                          className={ColorBadge(activity.status)}
                        >
                          {ActivityStatusLabel.get(activity.status)}
                        </KanbanCardFooterBadge>
                        <div className="flex items-center text-xs text-zinc-500">
                          <Clock className="mr-1 h-3 w-3" />
                          Saturday, 10:00 AM
                        </div>
                      </KanbanCardFooter>
                    </KanbanCard>
                  ))}
                </div>
              )}
            </KanbanColumn>
          ))
        )}
      </div>
    </div>
  );
}
