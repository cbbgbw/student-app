import { FormLabel, Select } from '@chakra-ui/react'
import React, { FC, forwardRef, InputHTMLAttributes } from 'react'
import { ReusableModal } from '../../ReusableModal/Modal'

interface Props extends InputHTMLAttributes<HTMLSelectElement> {
  labelText?: string
  bottomSpace?: boolean
  selectOptions: Record<string, string> | undefined
}

export const CSelect = forwardRef<HTMLSelectElement, Props>(
  ({ selectOptions, labelText, name, onChange, defaultValue }, ref) => {
    const renderMenuItems = () =>
      selectOptions &&
      Object.keys(selectOptions).map((opt) => (
        <option key={opt} value={opt}>
          {selectOptions[opt]}
        </option>
      ))

    return (
      <>
        <FormLabel htmlFor={name}>{labelText}</FormLabel>
        <Select
          defaultValue={defaultValue}
          onChange={onChange}
          marginBottom={15}
          ref={ref}
          name={name}
        >
          {renderMenuItems()}
        </Select>
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
