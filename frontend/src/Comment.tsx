import React, { useState } from "react";
import ReCAPTCHA from "react-google-recaptcha";

const SITE_KEY = "6LfZbc0rAAAAANCweN6MY0gPRyMVOSzzEYLvOYQ0";

export const CommentForm: React.FC = () => {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [text, setText] = useState("");
  const [captchaToken, setCaptchaToken] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!captchaToken) {
      alert("Пройдите CAPTCHA!");
      return;
    }

    const response = await fetch("http://localhost:5178/api/comments", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username, email, text, captchaToken }),
    });

    const data = await response.json();
    alert(data.message);
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder="Username"
        value={username}
        onChange={(e) => setUsername(e.target.value)}
        required
      />
      <input
        type="email"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        required
      />
      <textarea
        placeholder="Comment"
        value={text}
        onChange={(e) => setText(e.target.value)}
        required
      />
      <ReCAPTCHA
        sitekey={SITE_KEY}
        onChange={(token) => setCaptchaToken(token)}
      />
      <button type="submit">Submit</button>
    </form>
  );
};