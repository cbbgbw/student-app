import useSWR from 'swr'
import { fetcher } from '../axios'
import { parseISOString } from '../../utils/dateUtils'

interface Event {
  eventKey: string
  title: string
  content: string
  projectKey: string
  setTime: string
}

export const useEvents = () => {
  const { data, error } = useSWR<Event[] | undefined>('event/day/7', fetcher)

  const getEventsParsed = () => {
    let eventsParsed: Record<string, Event[]> = {}

    data?.forEach((event) => {
      const { setTime } = event

      const date = parseISOString(setTime)
      const dayOfTheMonth = 15 /*date.getUTCDay()*/

      if (!eventsParsed[dayOfTheMonth]) {
        eventsParsed[dayOfTheMonth] = []
      }
      eventsParsed[dayOfTheMonth].push(event)
    })
    return eventsParsed
  }

  return {
    events: data,
    getEventsParsed,
  }
}
