import { apiUrl } from '../app-config.json'
import axios from 'axios'

const createAxiosClient = () => {
  const defaults = {
    baseURL: apiUrl,
    headers: {
      'Content-Type': 'application/json',
    },
  }

  let instance = axios.create(defaults)

  instance.interceptors.request.use((config) => {
    const token = localStorage.getItem('token')
    config.headers.Authorization = token ? `Bearer ${JSON.parse(token)}` : ''
    console.log(config)
    return config
  })

  return instance
}

const axiosClient = createAxiosClient()

export const fetcher = async <T = {}>(url: string, params: T) =>
  await axiosClient.get(url, { params }).then((res) => res.data)

export enum Path {
  Subject = `subject`,
  Semester = 'semester',
  Project = 'project',
  User = 'user',
  Event = 'event',
}

export const postByScheme = async <T, Y = {}>(path: Path, data: T) =>
  await axiosClient.post<Y>(path, {
    date: new Date().toISOString(),
    [path]: data,
  })

export const postByQuery = async (query: string) =>
  await axiosClient.post(query)

export const postByBody = async <T>(path: string, data: T) =>
  await axiosClient.post(path, data)

export const putByQuery = async (query: string) => await axiosClient.put(query)
