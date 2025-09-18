import React from "react";
import type { CommentDto } from "../dtos/CommentDto";
import { CommentForm } from "./CommentForm";

interface Props {
  comments: CommentDto[];
  onCommentAdded: () => void;
}

export const CommentTree: React.FC<Props> = ({ comments, onCommentAdded }) => {
  return (
    <ul>
      {comments.map(c => (
        <li key={c.id}>
          <div className="comment">
            <b>{c.userName}</b> ({c.email}) - {c.createdAt ? new Date(c.createdAt).toLocaleString() : "–"}
            <p>{c.text}</p>
            <CommentForm parentId={c.id} onCommentAdded={onCommentAdded} />
            {c.replies.length > 0 && (
                <div style={{ marginTop: "8px" }}>
                <CommentTree comments={c.replies} onCommentAdded={onCommentAdded} />
                </div>
            )}
          </div>
        </li>
      ))}
    </ul>
  );
};