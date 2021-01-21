import useSWR from 'swr'
import { baseURL } from '../common/common'
import { getItemFromDictionary } from '../../utils/getters'

export const useUserSemesters = () => {
  const { data: semesters, error, mutate } = useSWR<Record<string, string>>(
    `${baseURL}/semester`,
  )

  const getCurrentSemester: () => [string, string] | undefined = () => {
    if (semesters) {
      const [key, value] = getItemFromDictionary(semesters)
      return [key, value]
    }
  }

  return {
    semesters,
    currentSemester: getCurrentSemester(),
    isLoading: !error && !semesters,
    isError: error,
    mutate,
  }
}
