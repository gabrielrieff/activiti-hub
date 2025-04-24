import { Skeleton } from "@/components/ui/skeleton";
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

export function KanbanLoading() {
  return (
    <div className="grid grid-cols-1 gap-6 md:grid-cols-3">
      {[1, 2, 3].map((columnIndex) => (
        <KanbanColumn key={columnIndex}>
          <KanbanColumnHeader>
            <KanbanTitle>
              <Skeleton className="h-6 w-24" />
            </KanbanTitle>
            <KanbanBadge>
              <Skeleton className="h-5 w-3 rounded-full" />
            </KanbanBadge>
          </KanbanColumnHeader>
          {[1, 2].map((cardIndex) => (
            <KanbanCard href="" key={cardIndex}>
              <KanbanCardHeader id="" href="">
                <KanbanCardTitle>
                  <Skeleton className="h-8 w-48" />
                </KanbanCardTitle>
              </KanbanCardHeader>
              <KanbanCardContent>
                <Skeleton className="h-12 w-full" />
              </KanbanCardContent>
              <KanbanCardFooter>
                <KanbanCardFooterBadge>
                  <Skeleton className="h-8 w-28" />
                </KanbanCardFooterBadge>
                <div className="flex items-center text-xs text-zinc-500">
                  <Skeleton className="h-8 w-20" />
                </div>
              </KanbanCardFooter>
            </KanbanCard>
          ))}
        </KanbanColumn>
      ))}
    </div>
  );
}
