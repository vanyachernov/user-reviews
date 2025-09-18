import axios from "axios";
import type { CommentDto } from "../dtos/CommentDto";

const API_URL = import.meta.env.VITE_API_URL;

export async function getComments(page: number, pageSize: number) {
  const result = await axios.get<CommentDto[]>(
    `${API_URL}/comments/GetAll?page=${page}&pageSize=${pageSize}`
  );
  return result.data;
}

export async function createComment(data: {
  userName: string;
  email: string;
  homepage?: string;
  parentId?: string;
  text: string;
  captchaToken?: string;
}) {
  const result = await axios.post<CommentDto>(`${API_URL}/comments/Create`, data);
  return result.data;
}
