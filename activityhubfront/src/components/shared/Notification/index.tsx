import { cn } from "@/lib/utils";
import { LucideProps } from "lucide-react";

export type NotificationGenericProps<T = unknown> = {
  children: React.ReactNode;
  className?: string;
} & T;

export function NotificationRoot({
  className,
  children,
}: NotificationGenericProps) {
  return (
    <div className={cn(["flex items-start justify-between gap-2", className])}>
      {children}
    </div>
  );
}

export function NotificationContent({
  className,
  children,
}: NotificationGenericProps) {
  return (
    <div
      className={cn([
        "flex flex-col text-sm gap-2 rounded-sm focus:bg-accent focus:text-accent-foreground",
        className,
      ])}
    >
      {children}
    </div>
  );
}

type NotificationIconProps = {
  Icon: React.ForwardRefExoticComponent<
    Omit<LucideProps, "ref"> & React.RefAttributes<SVGSVGElement>
  >;
};

export function NotificationIcon({
  className,
  Icon,
}: Omit<NotificationGenericProps<NotificationIconProps>, "children">) {
  return (
    <div>
      <Icon className={cn(["!size-6 text-yellow-600", className])} />
    </div>
  );
}
