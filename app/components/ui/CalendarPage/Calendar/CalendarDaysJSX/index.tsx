import React, { FC } from 'react'
import { JSX } from '@babel/types'
import { Grid, GridItem, List, Text } from '@chakra-ui/react'
import moment from 'moment'

interface Props {
  dayOfMonthToday: number | undefined
  daysBeforeMonth: number
  firstDayOfWeekInMonth: number
  daysInMonth: number
  daysAfterMonth: number
  onClickMonthBack: () => void
  onDateFieldClick: (day: number) => void
  selectedDayOfMonth: number | undefined
}

export const CalendarDaysJSX: FC<Props> = ({
  daysInMonth,
  firstDayOfWeekInMonth,
  onClickMonthBack,
  onDateFieldClick,
  selectedDayOfMonth,
  dayOfMonthToday,
}) => {
  const daysOnMonthView = []

  // Week headers

  for (let i = 1; i <= 7; i++) {
    daysOnMonthView.push(
      <GridItem
        display="flex"
        gridRowStart={1}
        paddingX="10px"
        borderRadius="15px"
        backgroundColor="#dadada"
        h="50px"
        alignItems="center"
        justifyContent="center"
      >
        <Text fontSize="22px">
          {moment().day(i).locale('pl').format('dddd')}
        </Text>
      </GridItem>,
    )
  }

  // Before month happens in week days

  for (let i = 1; i < firstDayOfWeekInMonth; i++) {
    daysOnMonthView.push(
      <GridItem
        opacity="0.4"
        paddingX="10px"
        borderRadius="15px"
        onClick={() => onClickMonthBack()}
        backgroundColor="#dadada"
        h="100px"
      />,
    )
  }

  // Days of week in selected month

  for (let i = 1; i <= daysInMonth; i++) {
    daysOnMonthView.push(
      <GridItem
        paddingX="10px"
        borderRadius="15px"
        gridColumnStart={i === 1 ? firstDayOfWeekInMonth : undefined}
        onClick={() => onDateFieldClick(i)}
        backgroundColor={
          i === dayOfMonthToday
            ? '#FFBA6B'
            : selectedDayOfMonth === i
            ? '#DCDAF2'
            : '#dadada'
        }
        border={i === selectedDayOfMonth ? '1px solid #FFBA6B' : undefined}
        h="100px"
      >
        <Text fontSize="22px">{i}</Text>
      </GridItem>,
    )
  }

  return (
    <List
      padding="25px"
      as={Grid}
      gridGap="25px"
      gridTemplateColumns="repeat(7, 1fr)"
    >
      {daysOnMonthView}
    </List>
  )
}
