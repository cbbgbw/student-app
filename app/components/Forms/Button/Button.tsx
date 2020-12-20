import React, { CSSProperties, FC } from "react";

type Button = {
  contrast: boolean;
  className?: string;
  style?: CSSProperties;
  onClick: () => void;
};

export const Button: FC<Button> = ({
  children,
  onClick,
  contrast = false,
  style
}) => (
  <button onClick={onClick} style={style}>
    {children}
    <style jsx>{`
      button {
        padding: 8px 12px 8px 12px;

        border: 1px solid ${contrast ? "#614d8c" : "white"};
        border-radius: 8px;

        background: ${!contrast ? "#614d8c" : "white"};
        color: ${contrast ? "#614d8c" : "white"};

        font-family: "Source Sans Pro Black", serif;
        font-size: 16px;

        cursor: pointer;

        transition: 0.25s;
      }
      button:hover {
        color: ${!contrast ? "#614d8c" : "white"};
        background: ${contrast ? "#614d8c" : "white"};
        border: 1px solid ${!contrast ? "#614d8c" : "white"};
      }
    `}</style>
  </button>
);
