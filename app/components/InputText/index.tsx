import React, { FC, useState } from 'react'
import { Text, Input, Heading, Select } from '@chakra-ui/react'

export enum TextType {
  Text,
  Heading,
}

interface Props {
  fontSize: string

  text: string
  onTextChanged: (key: string, value: string) => void
  title?: string
  keyModified: string
  textType?: TextType
}

export const InputText: FC<Props> = ({
  fontSize,
  onTextChanged,
  text,
  title,
  keyModified,
  textType = TextType.Text,
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
    textType === TextType.Text ? (
      <Text
        cursor="pointer"
        title={title}
        onClick={() => setIsEditMode(true)}
        fontSize={fontSize}
      >
        {text}
      </Text>
    ) : (
      <Heading
        cursor="pointer"
        title={title}
        onClick={() => setIsEditMode(true)}
        fontSize={fontSize}
      >
        {text}
      </Heading>
    )
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
