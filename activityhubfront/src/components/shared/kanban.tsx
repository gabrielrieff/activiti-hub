import { cn, deleteAct } from "@/lib/utils";
import { Badge } from "../ui/badge";
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "../ui/card";
import Link from "next/link";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "../ui/dropdown-menu";
import { MoreHorizontal } from "lucide-react";
import { Button } from "../ui/button";

export type SidebarGenericProps<T = unknown> = {
  children: React.ReactNode;
  className?: string;
} & T;

export function KanbanColumn({ children, className }: SidebarGenericProps) {
  return (
    <div className={cn(["p-4", className])}>
      <div className="space-y-3">{children}</div>
    </div>
  );
}

export function KanbanColumnHeader({
  children,
  className,
}: SidebarGenericProps) {
  return (
    <div className={cn(["flex items-center gap-2", className])}>{children}</div>
  );
}

export function KanbanTitle({ children, className }: SidebarGenericProps) {
  return (
    <h2
      className={cn([
        "font-semibold text-sm uppercase tracking-wide text-white",
        className,
      ])}
    >
      {children}
    </h2>
  );
}

export function KanbanBadge({ children, className }: SidebarGenericProps) {
  return (
    <Badge
      variant="secondary"
      className={cn(["rounded-full text-white bg-purple-500", className])}
    >
      {children}
    </Badge>
  );
}

type KanbanCardProps = {
  href: string;
  active?: boolean;
};

export function KanbanCard({
  children,
  className,
  href,
}: SidebarGenericProps<KanbanCardProps>) {
  return (
    <Link href={href} className={cn(["flex flex-col", className])}>
      <Card className="group bg-primary border-primary py-0">{children}</Card>
    </Link>
  );
}

type KanbanCardHeaderProps = {
  href: string;
  id: string;
};

export function KanbanCardHeader({
  children,
  className,
  id,
  href,
}: SidebarGenericProps<KanbanCardHeaderProps>) {
  return (
    <CardHeader className={cn(["p-4 pb-2", className])}>
      <div className="flex items-start justify-between">
        {children}
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
              <Link href={href}>Editar</Link>
            </DropdownMenuItem>

            <DropdownMenuItem
              onClick={() => deleteAct(id)}
              className="text-destructive"
            >
              Delete
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      </div>
    </CardHeader>
  );
}

export function KanbanCardTitle({ children, className }: SidebarGenericProps) {
  return (
    <CardTitle className={cn(["text-white font-semibold", className])}>
      {children}
    </CardTitle>
  );
}

export function KanbanCardContent({
  children,
  className,
}: SidebarGenericProps) {
  return (
    <CardContent className={cn(["p-4 pt-0", className])}>
      <div className="text-sm text-zinc-200 line-clamp-2">{children}</div>
    </CardContent>
  );
}

export function KanbanCardFooter({ children, className }: SidebarGenericProps) {
  return (
    <CardFooter
      className={cn(["p-4 pt-0 flex items-center justify-between", className])}
    >
      {children}
    </CardFooter>
  );
}

export function KanbanCardFooterBadge({
  children,
  className,
}: SidebarGenericProps) {
  return (
    <div
      className={cn(["px-2 py-1 rounded-full text-xs font-medium", className])}
    >
      {children}
    </div>
  );
}
