import { Color } from '../../../../../consts/colors'
import { Box, Button, Flex, Heading, Text } from '@chakra-ui/react'
import moment from 'moment'
import React, { FC } from 'react'
import ArrowRight from '../../../../../public/icons/calendar/arrowRight.svg'
import ArrowLeft from '../../../../../public/icons/calendar/arrowLeft.svg'

interface Props {
  year: string
  month: string
  onClickYearBack: () => void
  onClickYearForward: () => void
  onClickMonthBack: () => void
  onClickMonthForward: () => void
}

export const CalendarJSX: FC<Props> = ({
  year,
  month,
  onClickMonthBack,
  onClickMonthForward,
  onClickYearBack,
  onClickYearForward,
  children,
}) => (
  <Box borderRadius={'20px'} w="100%" h="100%" backgroundColor={Color.White}>
    <Flex flexDir="column" px="30px" pt="16px">
      <Flex justifyContent="center" alignItems="center">
        <Button background={'transparent'} onClick={onClickYearBack}>
          <ArrowLeft />
        </Button>
        <Heading px="20px" color="#D97602">
          {year}
        </Heading>
        <Button background={'transparent'} onClick={onClickYearForward}>
          <ArrowRight />
        </Button>
      </Flex>
      <Flex justifyContent="space-between">
        <Button background={'transparent'} onClick={onClickMonthBack}>
          <ArrowLeft />
        </Button>
        <Text fontSize="22px" color="#D97602">
          {month}
        </Text>
        <Button background={'transparent'} onClick={onClickMonthForward}>
          <ArrowRight />
        </Button>
      </Flex>
    </Flex>
    {children}
  </Box>
)
