import { Box, List } from '@chakra-ui/react'
import React, { FC } from 'react'
import { useEvents, useEventsForSubject } from '../../../../api/hooks/event'
import { Container } from '../Container'
import { EventListItem } from './EventListItem'

interface Props {
  subjectKey: string
}

export const EventList: FC<Props> = ({ subjectKey }) => {
  const { events } = useEventsForSubject(subjectKey)

  return (
    <Container maxHeight="300px" name="WYDARZENIA">
      <List display="flex" flexDir="column" px="20px" w="100%">
        {events?.map((event) => {
          const date = new Date(event.setTime)
          return (
            <EventListItem
              key={event.title}
              name={event.title}
              date={date.toDateString()}
            />
          )
        })}
      </List>
    </Container>
  )
}
