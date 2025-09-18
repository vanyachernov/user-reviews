export interface CommentDto {
  id: string;
  userName: string;
  email: string;
  homepage?: string;
  text: string;
  createdAt?: string;
  replies: CommentDto[];
}