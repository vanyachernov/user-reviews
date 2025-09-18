import React, { useEffect, useState } from "react";
import { getComments } from "../api/comments";
import type { CommentDto } from "../dtos/CommentDto";

interface Props {
  onCommentAdded: () => void;
}

export const CommentsTable: React.FC<Props> = ({ onCommentAdded }) => {
  const [page, setPage] = useState(1);
  const [comments, setComments] = useState<CommentDto[]>([]);
  const [sortField, setSortField] = useState<keyof CommentDto>("createdAt");
  const [sortOrder, setSortOrder] = useState<"asc" | "desc">("desc");
  const pageSize = 25;

  useEffect(() => {
    (async () => {
      const data = await getComments(page, pageSize);
      setComments(data);
    })();
  }, [page, onCommentAdded]);

  const sorted = [...comments].sort((a, b) => {
    const valA = a[sortField] ?? "";
    const valB = b[sortField] ?? "";

    if (sortField === "createdAt") {
      const timeA = a.createdAt ? new Date(a.createdAt).getTime() : 0;
      const timeB = b.createdAt ? new Date(b.createdAt).getTime() : 0;
      return sortOrder === "asc" ? timeA - timeB : timeB - timeA;
    }

    return (valA as string).localeCompare(valB as string) * (sortOrder === "asc" ? 1 : -1);
  });

  const toggleSort = (field: keyof CommentDto) => {
    if (sortField === field) {
      setSortOrder(prev => (prev === "asc" ? "desc" : "asc"));
    } else {
      setSortField(field);
      setSortOrder("asc");
    }
  };

  return (
    <div>
      <table>
        <thead>
          <tr>
            <th onClick={() => toggleSort("userName")}>Повне ім'я {sortField === "userName" ? (sortOrder === "asc" ? "↑" : "↓") : ""}</th>
            <th onClick={() => toggleSort("email")}>Пошта {sortField === "email" ? (sortOrder === "asc" ? "↑" : "↓") : ""}</th>
            <th onClick={() => toggleSort("createdAt")}>Дата створення {sortField === "createdAt" ? (sortOrder === "asc" ? "↑" : "↓") : ""}</th>
          </tr>
        </thead>
        <tbody>
          {sorted.map((c, index) => (
            <tr key={c.id ?? index}>
              <td>{c.userName}</td>
              <td>{c.email}</td>
              <td>{c.createdAt ? new Date(c.createdAt).toLocaleString() : "–"}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <div className="pagination">
        <button disabled={page === 1} onClick={() => setPage(p => p - 1)}>Назад</button>
        <span>Сторінка {page} </span>
        <button disabled={comments.length < pageSize} onClick={() => setPage(p => p + 1)}>Далі</button>
      </div>
    </div>
  );
};