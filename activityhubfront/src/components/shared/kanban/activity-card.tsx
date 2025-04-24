"use client";

import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Activity } from "@/communication/responses/@types/Activity";
import {
  ActivityStatus,
  ActivityStatusLabel,
} from "@/communication/responses/enum/ActivityStatus";
import Link from "next/link";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { Button } from "@/components/ui/button";
import { MoreHorizontal, Clock } from "lucide-react";
import { deleteAct } from "@/lib/utils";

interface TaskCardProps {
  activity: Activity;
}

export function ActivityCard({ activity }: TaskCardProps) {
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

  return (
    <Link
      key={activity.id}
      href={`activity/edit/${activity.id}`}
      className="flex flex-col"
    >
      <Card className="group bg-primary border-primary">
        <CardHeader className="p-4 pb-2">
          <div className="flex items-start justify-between">
            <CardTitle className="text-white font-semibold">
              {activity.title}
            </CardTitle>
            <DropdownMenu>
              <DropdownMenuTrigger asChild>
                <Button
                  variant="ghost"
                  size="icon"
                  className="h-8 w-8 text-white opacity-0 group-hover:opacity-100 transition-opacity"
                >
                  <MoreHorizontal className="h-4 w-4" />
                </Button>
              </DropdownMenuTrigger>
              <DropdownMenuContent align="end">
                <DropdownMenuItem>
                  <Link href={`activity/edit/${activity.id}`}>Editar</Link>
                </DropdownMenuItem>

                <DropdownMenuItem
                  onClick={() => deleteAct(activity.id.toString())}
                  className="text-destructive"
                >
                  Delete
                </DropdownMenuItem>
              </DropdownMenuContent>
            </DropdownMenu>
          </div>
        </CardHeader>
        <CardContent className="p-4 pt-0">
          <p className="text-sm text-zinc-200 line-clamp-2">
            {activity.description}
          </p>
        </CardContent>
        <CardFooter className="p-4 pt-0 flex items-center justify-between">
          <div
            className={`px-2 py-1 rounded-full text-xs font-medium ${ColorBadge(
              activity.status
            )}`}
          >
            {ActivityStatusLabel.get(activity.status)}
          </div>
          <div className="flex items-center text-xs text-zinc-500">
            <Clock className="mr-1 h-3 w-3" />
            Saturday, 10:00 AM
          </div>
        </CardFooter>
      </Card>
    </Link>
  );
}
