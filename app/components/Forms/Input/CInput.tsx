import React, { forwardRef, InputHTMLAttributes } from 'react'
import { FormLabel, Input, Flex } from '@chakra-ui/react'
import { InputProps } from '@chakra-ui/input/dist/types/input'

interface Props extends InputProps {
  labelText?: string
}

export const CInput = forwardRef<HTMLInputElement, Props>(
  ({ name, labelText, size = 'md', variant, placeholder, type }, ref) => (
    <Flex direction="column" mb={15}>
      <FormLabel htmlFor={name}>{labelText}</FormLabel>
      <Input
        placeholder={placeholder}
        variant={variant}
        size={size}
        id={name}
        name={name}
        type={type}
        ref={ref}
      />
    </Flex>
  ),
)
