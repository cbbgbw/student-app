import useSWR from 'swr'
import { fetcher, Path } from '../axios'

// export const useUser = () => {
//   const { data: userData, error } = useSWR<semesterGetResponse>(
//     'user/current',
//     fetcher,
//   )
//
//   const getCurrentSemester = () => [
//     userData?.item1,
//     userData?.item2[userData?.item1],
//   ]
//
//   return {
//     currentSemester: getCurrentSemester(),
//     isError: !!error,
//   }
// }

export const useUser
