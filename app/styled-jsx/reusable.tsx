import React, { FC } from "react";

export const ChildrenWithinDivInRow: FC = ({ children }) => (
  <div>
    {children}
    <style jsx>{`
      div {
        display: flex;
        flex-direction: row;
      }
    `}</style>
  </div>
);
