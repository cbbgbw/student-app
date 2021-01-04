import React, {
  ButtonHTMLAttributes,
  CSSProperties,
  FC,
} from 'react';

type Props = ButtonHTMLAttributes<HTMLButtonElement> & {
  contrast: boolean;
};

export const Button: FC<Props> = ({
  children,
  onClick,
  contrast = false,
  style,
  type = 'button',
}) => (
  <button type={type} onClick={onClick} style={style}>
    {children}
    <style jsx>{` 
      button { 
        padding: 8px 12px 8px 12px;

        border: 1px solid ${contrast ? '#614d8c' : "white"};
        border-radius: 8px;

        background: ${!contrast ? '#614d8c' : 'white'};
        color: ${contrast ? '#614d8c' : 'white'};

        font-family: 'Source Sans Pro Black', serif;
        font-size: 16px;

        cursor: pointer;

        transition: 0.25s;
        outline: none;
      }
      button:hover {
        color: ${!contrast ? '#614d8c' : 'white'};
        background: ${contrast ? '#614d8c' : 'white'};
        border: 1px solid ${!contrast ? '#614d8c' : 'white'};
      }
    `}</style>
  </button>
);
