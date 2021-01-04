import React, { FC, forwardRef } from 'react'
import clsx from 'clsx'

interface Props {
  name?: string
  type?: string
  labelText?: string
  labelPosition?: 'flex-start' | 'center' | 'flex-end'
  bottomSpace?: boolean
  disabled?: boolean
}

export const MultiLineInput: FC<Props> = forwardRef<
  HTMLTextAreaElement,
  Props
>(
  (
    { name, bottomSpace, labelText, disabled, type, labelPosition },
    ref,
  ) => (
    <div className={clsx('inputBox', bottomSpace && 'bottomSpace')}>
      <label htmlFor={name}>{labelText}</label>
      <textarea id={name} disabled={disabled} name={name} ref={ref} />
      <style jsx>{`
        .inputBox {
          display: flex;
          flex-direction: ${type === 'checkbox'
            ? 'row-reverse'
            : 'column'};
          align-items: ${type === 'checkbox' ? 'center' : 'unset'};
          width: 300px;
        }

        .bottomSpace {
          margin-bottom: 15px;
        }

        label {
          color: #322f47;
          font-family: 'Source Sans Pro Semi-Bold', sans-serif;
          text-align: ${labelPosition};
          font-size: 14px;
          margin-bottom: 5px;
        }

        textarea {
          font-family: 'Source Sans Pro', sans-serif;
          border-radius: 6px;
          border: 1px solid #322f47;
          font-size: 16px;

          padding: 8px;

          background-color: white;
          resize: none;
        }

        textarea:focus {
          border: 1px solid #55517a;
        }

        textarea:disabled {
          background-color: #c5c5c7;
        }
      `}</style>
    </div>
  ),
)
