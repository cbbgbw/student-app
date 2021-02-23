import React, { FC, useState } from 'react'
import { Text, Input, Select } from '@chakra-ui/react'

interface Props {
  fontSize: string
  text: string
  onTextChanged: (key: string, value: string) => void
  title: string
  keyModified: string
}

export const InputText: FC<Props> = ({
  fontSize,
  onTextChanged,
  text,
  title,
  keyModified,
}) => {
  const [isEditMode, setIsEditMode] = useState(false)

  const onInputBlur = (e: React.FocusEvent<HTMLInputElement>) => {
    const textFromInput = e.target.value
    if (textFromInput !== '' && textFromInput !== text) {
      onTextChanged(keyModified, textFromInput)
    }
    setIsEditMode(false)
  }

  return !isEditMode ? (
    <Text
      cursor="pointer"
      title={title}
      onClick={() => setIsEditMode(true)}
      fontSize={fontSize}
    >
      {text}
    </Text>
  ) : (
    <Input
      onBlur={onInputBlur}
      variant="flushed"
      autoFocus
      fontSize={fontSize}
      defaultValue={text}
    />
  )
}
