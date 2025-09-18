import axios from "axios";
import type { CommentDto } from "../dtos/CommentDto";

export async function getComments(page: number, pageSize: number) {
  const res = await axios.get<CommentDto[]>(`http://localhost:5178/api/comments/GetAll?page=${page}&pageSize=${pageSize}`);
  return res.data;
}

export async function createComment(data: {
  userName: string;
  email: string;
  homepage?: string;
  parentId?: string;
  text: string;
  captchaToken: string;
}) {
  const res = await axios.post<CommentDto>("http://localhost:5178/api/comments/Create", data);
  return res.data;
}
