import React, { useState } from "react";

interface Props {
  parentId?: string;
  onCommentAdded: () => void;
}

const SITE_KEY = "6LdHYc0rAAAAANUNBCGnRCOkC3O1xv44zJDCk1BM";

export const CommentForm: React.FC<Props> = ({ parentId, onCommentAdded }) => {
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [text, setText] = useState("");
  // const [captchaToken, setCaptchaToken] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    // if (!captchaToken) {
    //   alert("Please complete CAPTCHA!");
    //   return;
    // }

    try {
      await fetch("http://localhost:5178/api/comments/Create", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ userName, email, text, parentId }),
      });
      setUserName("");
      setEmail("");
      setText("");
      onCommentAdded();
    } catch (err) {
      console.error(err);
      alert("Error adding comment");
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