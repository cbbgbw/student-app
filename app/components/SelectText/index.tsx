import React, { FC, useState } from 'react'
import { Text, Input, Select, Heading } from '@chakra-ui/react'
import { renderMenuItems } from '../Forms/CSelect/CSelect'
import { TextType } from '../InputText'
import { FlexCentered } from '../chakra/FlexCentered'

interface Props {
  fontSize: string
  text: string
  onChange: (key: string, value: string) => void
  title?: string
  options: Record<string, string> | undefined
  keyModified: string
  selectedKey: string
  textType: TextType
}

export const SelectText: FC<Props> = ({
  fontSize,
  onChange,
  text,
  title,
  options,
  keyModified,
  selectedKey,
  textType = TextType.Text,
}) => {
  const [isEditMode, setIsEditMode] = useState(false)

  const onBlur = () => {
    setIsEditMode(false)
  }

  const onOptionChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    onBlur()
    const textFromInput = e.target.value
    onChange(keyModified, textFromInput)
  }

  return !isEditMode || !options ? (
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
    <Select
      color={'white'}
      autoFocus
      variant="flushed"
      onBlur={onBlur}
      onChange={onOptionChange}
      fontSize={fontSize}
      defaultValue={selectedKey}
    >
      {renderMenuItems(options)}
    </Select>
  )
}
