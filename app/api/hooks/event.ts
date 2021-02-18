import useSWR from 'swr'
import { fetcher } from '../axios'
import { getDateFormatted, parseISOString } from '../../utils/dateUtils'

interface Event {
  eventKey: string
  title: string
  content: string
  projectKey: string
  setTime: string
}

const getEventsParsed = (data: Event[]) => {
  let eventsParsed: Record<string, Event[]> = {}

  data?.forEach((event) => {
    const { setTime } = event

    const dateFormatted = getDateFormatted(setTime)

    if (!eventsParsed[dateFormatted]) {
      eventsParsed[dateFormatted] = []
    }
    eventsParsed[dateFormatted].push(event)
  })
  return eventsParsed
}

export const useEvents = () => {
  const { data, error } = useSWR<Event[] | undefined>('event/day/7', fetcher)

  return {
    events: data,
    getEventsParsed: () => data && getEventsParsed(data),
  }
}

export const useEventsForSubject = (subjectKey: string) => {
  const { data, error } = useSWR<Event[] | undefined>(
    `event/project/${subjectKey}`,
    fetcher,
  )

  return {
    events: data,
    getEventsParsed: () => data && getEventsParsed(data),
  }
}
