import React, { FC, useEffect, useState } from 'react'
import {
  NumberDecrementStepper,
  NumberIncrementStepper,
  NumberInput,
  NumberInputField,
  NumberInputStepper,
} from '@chakra-ui/react'

interface SemesterNumberInputProps {
  onChange: (semesterVal: number) => void
  semester?: number
}

export const SemesterNumberInput: FC<SemesterNumberInputProps> = ({
  onChange,
  semester,
}) => (
  <NumberInput
    value={semester}
    onChange={(v) => onChange(Number(v))}
    size="lg"
    min={1}
    max={12}
    color="purple.200"
    defaultValue={1}
    mb="12px"
  >
    <NumberInputField />
    <NumberInputStepper>
      <NumberIncrementStepper />
      <NumberDecrementStepper />
    </NumberInputStepper>
  </NumberInput>
)
