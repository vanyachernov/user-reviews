import React, { useState } from "react";
import { createComment } from "../api/comments.ts";

interface Props {
  parentId?: string;
  onCommentAdded: () => void;
}

export const CommentForm: React.FC<Props> = ({ parentId, onCommentAdded }) => {
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [text, setText] = useState("");
  // const [captchaToken, setCaptchaToken] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      await createComment({ userName, email, text, parentId });
      setUserName("");
      setEmail("");
      setText("");
      onCommentAdded();
    } catch (err) {
      console.error(err);
      console.log("Error adding comment. Please, try again!");
    }
  };

  return (
    <form onSubmit={handleSubmit} className="comment-form">
      <input value={userName} onChange={e => setUserName(e.target.value)} placeholder="Ім'я" required />
      <input value={email} onChange={e => setEmail(e.target.value)} placeholder="Пошта" required type="email"/>
      <textarea value={text} onChange={e => setText(e.target.value)} placeholder="Коментар" required />
      {/* <ReCAPTCHA sitekey={SITE_KEY} onChange={token => setCaptchaToken(token)} /> */}
      <button type="submit">Додати</button>
    </form>
  );
};