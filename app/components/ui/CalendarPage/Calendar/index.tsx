import moment from 'moment'
import React, { useState } from 'react'
import { CalendarJSX } from './CalendarJSX'
import { CalendarDaysJSX } from './CalendarDaysJSX'
import { Box, Flex } from '@chakra-ui/react'
import { EventList, EventListType } from '../../common/EventList'
import { useEventsForDate } from '../../../../api/hooks/event'

export const Calendar = () => {
  const todayDay = new Date()
  const [currentDate, setCurrentDate] = useState(todayDay.toISOString())
  const [selectedDate, setSelectedDate] = useState({
    isoString: '',
    isSelected: false,
  })

  const currentDateParsed = new Date(currentDate)

  const momentedDate = moment(currentDateParsed).locale('pl')
  const currentYear = momentedDate?.format('YYYY')
  const currentMonth = momentedDate?.format('MMMM')

  const { events } = useEventsForDate(
    currentDateParsed.getMonth() + 1,
    currentDateParsed.getUTCFullYear(),
  )

  /**

   * Number which indicate first day of week (for example friday, tuesday), as number
   */
  const firstDayInMonth = new Date(
    currentDateParsed.getFullYear(),
    currentDateParsed.getMonth(),
    1,
  ).getDay()

  const lastDayOfTheMonth =
    32 -
    new Date(
      currentDateParsed.getFullYear(),
      currentDateParsed.getMonth(),
      32,
    ).getDate()

  const onDateChange = (plus: boolean, isMonthChanged: boolean) => {
    if (isMonthChanged) {
      currentDateParsed?.setMonth(
        plus
          ? currentDateParsed?.getMonth() + 1
          : currentDateParsed?.getMonth() - 1,
      )
    } else {
      currentDateParsed?.setFullYear(
        plus
          ? currentDateParsed?.getFullYear() + 1
          : currentDateParsed?.getFullYear() - 1,
      )
    }
    setCurrentDate(currentDateParsed.toISOString())
  }

  const onDateFieldClick = (number: number) => {
    if (new Date(selectedDate.isoString).getDate() === number) {
      setSelectedDate({ ...selectedDate, isSelected: !selectedDate.isSelected })
    } else {
      currentDateParsed.setDate(number)
      setSelectedDate({
        isoString: currentDateParsed.toISOString(),
        isSelected: true,
      })
    }
  }

  const selectedDayParsed =
    selectedDate.isSelected && new Date(selectedDate.isoString)
  const selectedDay =
    (selectedDayParsed &&
      selectedDayParsed.getMonth() === currentDateParsed.getMonth() &&
      selectedDayParsed.getFullYear() === currentDateParsed.getFullYear() &&
      selectedDayParsed.getDate()) ||
    undefined

  const todayDayForComps =
    (todayDay.getMonth() === currentDateParsed.getMonth() &&
      todayDay.getFullYear() === currentDateParsed.getFullYear() &&
      todayDay.getDate()) ||
    undefined

  return (
    <Flex flexDir="row" h="100%">
      <CalendarJSX
        year={currentYear}
        month={currentMonth}
        onClickYearBack={() => onDateChange(false, false)}
        onClickYearForward={() => onDateChange(true, false)}
        onClickMonthBack={() => onDateChange(false, true)}
        onClickMonthForward={() => onDateChange(true, true)}
      >
        <CalendarDaysJSX
          dayOfMonthToday={todayDayForComps}
          daysBeforeMonth={firstDayInMonth}
          firstDayOfWeekInMonth={firstDayInMonth}
          daysInMonth={lastDayOfTheMonth}
          daysAfterMonth={2}
          onClickMonthBack={() => onDateChange(false, true)}
          onDateFieldClick={onDateFieldClick}
          selectedDayOfMonth={selectedDay}
        />
      </CalendarJSX>
      <Box marginLeft="20px">
        <EventList
          events={
            selectedDate.isSelected
              ? events?.filter((event) => {
                  const evDate = new Date(event.setTime)
                  const isDayEqual = evDate.getDate() === selectedDay
                  const isMonthEqual =
                    evDate.getMonth() === currentDateParsed.getMonth()
                  const isYearEqual =
                    evDate.getFullYear() === currentDateParsed.getFullYear()

                  return isDayEqual && isMonthEqual && isYearEqual
                })
              : events
          }
          type={
            selectedDate.isSelected && selectedDay
              ? EventListType.Day
              : EventListType.Month
          }
        />
      </Box>
    </Flex>
  )
}
