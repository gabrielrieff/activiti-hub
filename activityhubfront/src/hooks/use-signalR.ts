import { useEffect, useRef } from "react";
import * as signalR from "@microsoft/signalr";
import { NotificationStatus } from "@/communication/responses/@types/Notification";

type NotificationCallback = {
  onListNotification: (notifications: NotificationStatus[]) => void;
  onSingleNotification: (notification: NotificationStatus) => void;
};

export default function useSignalR(
  userId: string,
  callbacks: NotificationCallback
) {
  const connectionRef = useRef<signalR.HubConnection | null>(null);

  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl(`http://localhost:5231/hubs/notifications?userId=${userId}`)
      .withAutomaticReconnect()
      .build();

    connection.on(
      "ReceiveListNotification",
      (notifications: NotificationStatus[]) => {
        callbacks.onListNotification(notifications);
      }
    );

    connection.on("ReceiveNotification", (notification: NotificationStatus) => {
      callbacks.onSingleNotification(notification);
    });

    connection
      .start()
      .then(() => {
        console.log("Connected in SignalR");
      })
      .catch(console.error);

    connectionRef.current = connection;

    return () => {
      connection.stop();
    };
  }, [userId]);

  async function markNotificationsAsRead(id: string) {
    try {
      if (!connectionRef.current) return;

      await connectionRef.current.invoke("MarkAsReadNotification", id);
      console.log("Notificações marcadas como lidas!");
    } catch (err) {
      console.error("Erro ao marcar notificações como lidas:", err);
    }
  }

  return {
    markNotificationsAsRead,
  };
}
