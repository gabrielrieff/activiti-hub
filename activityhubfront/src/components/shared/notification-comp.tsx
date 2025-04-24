"use client";

import { Bell, CheckCheck, Lightbulb, Settings } from "lucide-react";
import { Button } from "../ui/button";
import { useEffect, useState } from "react";
import useSignalR from "@/hooks/use-signalR";
import { NotificationStatus } from "@/communication/responses/@types/Notification";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "../ui/dropdown-menu";
import {
  NotificationContent,
  NotificationIcon,
  NotificationRoot,
} from "./Notification";

export function NotificationComp() {
  const [notifications, setNotifications] = useState<NotificationStatus[]>([]);
  const [notificationNoRead, setNotificationNoRead] = useState<number>(0);

  const { markNotificationsAsRead } = useSignalR("1", {
    onListNotification: (msg) => {
      setNotifications(msg);
    },
    onSingleNotification: (notification) => {
      setNotifications((prev) => [...prev, notification]);
    },
  });

  function countNotificationNoRead(): number {
    return notifications.filter((noti) => noti.isRead === false).length;
  }

  useEffect(() => {
    setNotificationNoRead(countNotificationNoRead());
  }, [notifications]);

  function tempoDecorrido(dataEnvio: string, dataAtual = new Date()) {
    const envio = new Date(dataEnvio);
    const atual = new Date(dataAtual);

    const diffMs = atual.getTime() - envio.getTime();
    const segundos = Math.floor(diffMs / 1000);
    const minutos = Math.floor(segundos / 60);
    const horas = Math.floor(minutos / 60);
    const dias = Math.floor(horas / 24);
    const meses = Math.floor(dias / 30); // Aproximado
    const anos = Math.floor(dias / 365); // Aproximado

    if (anos > 0) return `há ${anos} ano${anos > 1 ? "s" : ""}`;
    if (meses > 0) return `há ${meses} mês${meses > 1 ? "es" : ""}`;
    if (dias > 0) return `há ${dias} dia${dias > 1 ? "s" : ""}`;
    if (horas > 0) return `há ${horas} hora${horas > 1 ? "s" : ""}`;
    if (minutos > 0) return `há ${minutos} minuto${minutos > 1 ? "s" : ""}`;
    return `há poucos segundos`;
  }

  async function NotificationsAsRead(id: string) {
    markNotificationsAsRead(id).then(() => {
      setNotifications((prevNotifications) =>
        prevNotifications.map((notification) =>
          notification.id === id
            ? { ...notification, isRead: true }
            : notification
        )
      );
    });
  }

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="ghost" size="icon" className="relative">
          <Bell className="h-5 w-5" />
          <span className="absolute -top-1 -right-1 flex h-4 w-4 items-center justify-center rounded-full bg-primary text-[10px] text-white">
            {notificationNoRead}
          </span>
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent className="w-80" align="end">
        <DropdownMenuGroup>
          <div className="py-2 px-4 flex justify-between">
            <span className="font-semibold">Notificações</span>
            <Settings />
          </div>
        </DropdownMenuGroup>
        <DropdownMenuSeparator />
        {notifications
          .filter((n) => n.isRead === false)
          .slice(-3)
          .map((notification) => (
            <DropdownMenuItem key={notification.id}>
              <NotificationRoot>
                <NotificationIcon Icon={Lightbulb} />
                <NotificationContent>
                  <div className="flex items-center gap-3">
                    <span className="font-black text-purple-800">
                      Novidades
                    </span>
                    <span className="text-zinc-400 text-[11px]">
                      {tempoDecorrido(notification.createdAt)}
                    </span>
                  </div>
                  <span className="text-sm">{notification.message}</span>
                </NotificationContent>
                <Button
                  onClick={() => NotificationsAsRead(notification.id)}
                  variant="ghost"
                  size="icon"
                  className="hover:cursor-pointer hover:bg-purple-700"
                >
                  <CheckCheck className="text-black" />
                </Button>
              </NotificationRoot>
            </DropdownMenuItem>
          ))}
        <DropdownMenuSeparator />

        <DropdownMenuGroup>
          <DropdownMenuItem>
            <span className="w-full h-full text-center cursor-pointer font-extrabold">
              Ver todas
            </span>
          </DropdownMenuItem>
        </DropdownMenuGroup>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}
