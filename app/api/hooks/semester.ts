import useSWR, { mutate } from 'swr'
import { fetcher, Path, postByQuery, putByQuery } from '../axios'

interface semesterGetResponse {
  item1: string
  item2: Record<string, number>
}

export const useSemesters = () => {
  const {
    data: semesters,
    mutate: updateSemesters,
  } = useSWR<semesterGetResponse>(Path.Semester, fetcher)

  const getCurrentSemester = (): [string, number] | undefined =>
    semesters && [semesters.item1, semesters.item2[semesters.item1]]

  const changeSemesterToExisting = async (key: string) => {
    await updateSemesters(
      {
        item2: { ...semesters?.item2 },
        item1: key,
      },
      false,
    )
    await putByQuery(`${Path.Semester}/${key}`)
    await updateSemesters(undefined, true)
  }

  const changeSemesterToNew = async (value: number) => {
    await updateSemesters(
      {
        item1: 'new',
        item2: {
          ...semesters?.item2,
          new: value,
        },
      },
      false,
    )
    await postByQuery(`${Path.Semester}/${value}`)
    await updateSemesters()
  }

  return {
    currentSemester: getCurrentSemester(),
    semesters: semesters?.item2,
    changeSemesterToExisting,
    changeSemesterToNew,
  }
}
