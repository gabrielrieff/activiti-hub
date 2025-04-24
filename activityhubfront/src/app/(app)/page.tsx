"use client";

import { useEffect, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { getActivities, getActivitiesResponse } from "@/http/get-activities";
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
} from "@/components/shared/kanban";
import { KanbanLoading } from "@/components/shared/kanban-loading";
import {
  ActivityStatus,
  ActivityStatusLabel,
} from "@/communication/responses/enum/ActivityStatus";
import { Button } from "@/components/ui/button";
import Link from "next/link";

export default function Home() {
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
  return (
    <div className="relative w-full xl:px-40 px-6 flex flex-col">
      <div className="bg-primary flex items-center py-5 justify-between text-white sticky top-16 z-10">
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

      {isLoading ? (
        <KanbanLoading />
      ) : (
        <div className="flex gap-1 relative mb-5">
          {columns.map((column) => (
            <div key={column.id} className="bg-secondary rounded-2xl w-full">
              <KanbanColumnHeader className="bg-zinc-700 py-4 p-4 sticky top-40 z-10">
                <KanbanTitle>{column.title}</KanbanTitle>
                <KanbanBadge>{column.listActivities.length}</KanbanBadge>
              </KanbanColumnHeader>
              <KanbanColumn className="">
                {column.listActivities.length === 0 ? (
                  <KanbanCard href="">
                    <div className="min-h-[180px] rounded-lg border border-dashed border-gray-200 dark:border-gray-800 flex items-center justify-center">
                      <p className="text-muted-foreground text-sm">
                        Drop tasks here
                      </p>
                    </div>
                  </KanbanCard>
                ) : (
                  <div className="space-y-3 relative">
                    {column.listActivities.map((activity) => (
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
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
