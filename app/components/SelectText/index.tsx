import React, { FC, useState } from 'react'
import { Text, Input, Select } from '@chakra-ui/react'
import { renderMenuItems } from '../Forms/CSelect/CSelect'

interface Props {
  fontSize: string
  text: string
  onChange: (key: string, value: string) => void
  title: string
  options: Record<string, string> | undefined
  keyModified: string
  selectedKey: string
}

export const SelectText: FC<Props> = ({
  fontSize,
  onChange,
  text,
  title,
  options,
  keyModified,
  selectedKey,
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
    <Text
      cursor="pointer"
      title={title}
      onClick={() => setIsEditMode(true)}
      fontSize={fontSize}
    >
      {text}
    </Text>
  ) : (
    <Select
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
