import { FormLabel, Textarea } from '@chakra-ui/react'
import React, { forwardRef, InputHTMLAttributes } from 'react'

interface Props extends InputHTMLAttributes<HTMLSelectElement> {
  labelText?: string
}

export const CTextArea = forwardRef<HTMLTextAreaElement, Props>(
  ({ labelText, name, disabled }, ref) => {
    return (
      <>
        <FormLabel htmlFor={name}>{labelText}</FormLabel>
        <Textarea id={name} disabled={disabled} name={name} ref={ref} />
      </>
    )
  },
)

// import React, { forwardRef, InputHTMLAttributes } from 'react'
// import clsx from 'clsx'
//
// interface Props extends InputHTMLAttributes<HTMLSelectElement> {
//   labelText?: string
//   labelPosition?: 'flex-start' | 'center' | 'flex-end'
//   bottomSpace?: boolean
//   selectOptions: Record<string, string> | undefined
// }
//
// export const CSelect = forwardRef<HTMLSelectElement, Props>(
//   (
//     {
//       name,
//       disabled,
//       labelText,
//       labelPosition,
//       bottomSpace = true,
//       selectOptions,
//     },
//     ref,
//   ) => {

//
//     return (
//       <div className={clsx('inputBox', bottomSpace && 'bottomSpace')}>
//         <label htmlFor={name}>{labelText}</label>
//         <select disabled={disabled} id={name} name={name} ref={ref}>
//           <option value="">Wybierz...</option>
//           {renderMenuItems() ?? <option>loading</option>}
//         </select>
//         <style jsx>{`
//           .inputBox {
//             display: flex;
//             flex-direction: column;
//             align-items: unset;
//             width: 300px;
//           }
//
//           .bottomSpace {
//             margin-bottom: 15px;
//           }
//
//           label {
//             color: #322f47;
//             font-family: 'Source Sans Pro Semi-Bold', sans-serif;
//             text-align: ${labelPosition};
//             font-size: 14px;
//             margin-bottom: 5px;
//           }
//
//           select {
//             font-family: 'Source Sans Pro', sans-serif;
//             border-radius: 6px;
//             border: 1px solid #322f47;
//             font-size: 16px;
//
//             padding: 8px;
//
//             background-color: white;
//             resize: none;
//             outline: none;
//           }
//
//           select:focus {
//             border: 1px solid #55517a;
//           }
//
//           select:disabled {
//             background-color: #c5c5c7;
//           }
//         `}</style>
//       </div>
//     )
//   },
// )
