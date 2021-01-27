import React, { ButtonHTMLAttributes, FC } from 'react'
import { DefaultButtonContrastColor, LeadingColor } from '../../../types/color'

type Props = ButtonHTMLAttributes<HTMLButtonElement> & {
  contrast?: boolean
}

const getColor = (contrast: boolean) =>
  contrast ? LeadingColor : DefaultButtonContrastColor

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

        border: 1px solid ${getColor(contrast)};
        border-radius: 8px;

        background: ${getColor(!contrast)};
        color: ${getColor(contrast)};

        font-family: 'Source Sans Pro Black', serif;
        font-size: 16px;

        cursor: pointer;

        transition: 0.25s;
        outline: none;
      }

      button:hover {
        color: ${getColor(!contrast)};
        background: ${getColor(contrast)};
        border: 1px solid ${getColor(!contrast)};
      }
    `}</style>
  </button>
)
