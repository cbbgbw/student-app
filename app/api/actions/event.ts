import { Path, postByScheme } from '../axios'
import { v4 as uuidv4 } from 'uuid'

interface EventProps {
  eventKey: string
}

export interface EventFormData {
  title: string
  content: string
  projectKey: string
  setTime: string
}

type EventPost = EventProps & EventFormData

export const postEvent = async (data: EventFormData) =>
  await postByScheme<EventPost>(Path.Event, {
    ...data,
    eventKey: uuidv4(),
  }).then((response) => response.status === 201)
