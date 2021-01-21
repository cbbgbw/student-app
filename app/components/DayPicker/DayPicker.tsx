import { Flex } from '@chakra-ui/react'
import React, { FC, useState } from 'react'
import DayPicker from 'react-day-picker'
import TimeKeeper from 'react-timekeeper'

interface Props {
  onDateChange: (date: Date) => void
  date: Date
}
export const CDayPicker: FC<Props> = ({ date, onDateChange }) => {
  const hour = date.getHours()
  const minute = date.getMinutes()

  return (
    <Flex flex-direction="row">
      <DayPicker
        selectedDays={date}
        onDayClick={(newDate) => {
          const hour = date.getHours()
          const minute = date.getMinutes()
          newDate.setMinutes(minute)
          newDate.setHours(hour)
          onDateChange(newDate)
        }}
      />
      <TimeKeeper
        hour24Mode={true}
        time={{ hour, minute }}
        onChange={(data) => {
          const { hour, minute } = data
          date.setMinutes(minute)
          date.setHours(hour)
          onDateChange(date)
        }}
      />
    </Flex>
  )
}
