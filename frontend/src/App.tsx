import React, { useEffect, useState } from "react";
import { CommentsTable } from "./components/CommentsTable";
import { CommentTree } from "./components/CommentTree";
import { CommentForm } from "./components/CommentForm";
import { getComments } from "./api/comments";
import type { CommentDto } from "./dtos/CommentDto";
import "./styles.css";

const App: React.FC = () => {
  const [comments, setComments] = useState<CommentDto[]>([]);
  const [reloadFlag, setReloadFlag] = useState(false);

  const reloadComments = async () => {
    const data = await getComments(1, 25);
    setComments(data);
  };

  useEffect(() => {
    reloadComments();
  }, [reloadFlag]);

  return (
    <div className="container">
      <h1>Коментарі</h1>
      <CommentForm onCommentAdded={() => setReloadFlag(f => !f)} />
      <h2>Верхній рівень</h2>
      <CommentsTable onCommentAdded={() => setReloadFlag(f => !f)} />
      <h2>Дерево</h2>
      <CommentTree comments={comments} onCommentAdded={() => setReloadFlag(f => !f)} />
    </div>
  );
};

export default App;