export type NotificationStatus = {
  id: string;
  recipientUserId: number;
  recipientEmail: string;
  message: string;
  isRead: boolean;
  createdAt: string;
};
