import clsx from "clsx";
import React, { FC, LegacyRef } from "react";

type Input = React.InputHTMLAttributes<HTMLInputElement> & {
  //TODO Add multiline for descriptions
  name?: string;
  ref?: LegacyRef<HTMLInputElement> & LegacyRef<HTMLTextAreaElement>;
  type?: string;
  labelText?: string;
  labelPosition?: "flex-start" | "center" | "flex-end";
  bottomSpace?: boolean;
  isMultiline?: boolean;
};

export const Input: FC<Input> = ({
  name,
  ref,
  type,
  labelText,
  labelPosition = "left",
  bottomSpace = true,
  isMultiline = false
}) => {
  return (
    <div className={clsx("inputBox", bottomSpace && "bottomSpace")}>
      <label>{labelText}</label>
      {isMultiline ? (
        <textarea name={name} ref={ref} />
      ) : (
        <input name={name} ref={ref} type={type} />
      )}
      <style jsx>{`
        .inputBox {
          display: flex;
          flex-direction: column;

          width: 300px;
        }

        .bottomSpace {
          margin-bottom: 15px;
        }

        label {
          color: #322f47;
          font-family: "Source Sans Pro Semi-Bold", sans-serif;
          text-align: ${labelPosition};
          font-size: 14px;
          margin-bottom: 5px;
        }

        input,
        textarea {
          border-radius: 6px;
          border: 1px solid #322f47;
          font-size: 16px;

          padding: 8px;

          background-color: white;
        }

        input:focus {
          border: 1px solid #55517a;
        }
      `}</style>
    </div>
  );
};
