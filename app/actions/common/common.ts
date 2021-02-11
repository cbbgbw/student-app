import axios from 'axios'
import { Path } from '../../api/axios'

export const post = <T>(path: Path, data: T) =>
  axios.post(path, {
    date: new Date().toISOString(),
    [path]: data,
  })

export const customPost = <T, Y>(customPath: string, data: T) =>
  axios.post<Y>(customPath, data)

// export const get = <T>(path:Path)

export const request = {
  post: async <T>(path: Path, data: T) =>
    await axios.post(path, data).then(({ data }) => data),
  bodyLessPost: async <T>(path: string) =>
    await axios.post(path).then(({ data }) => data),
  bodyLessPut: async <T>(path: string) => await axios.put(path),
}
