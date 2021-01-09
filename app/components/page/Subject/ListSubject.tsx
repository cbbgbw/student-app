import { FC } from 'react'
import { useRouter } from 'next/router'
import { AppBackgroundColor, DefaultButtonContrastColor, LeadingColor } from '../../../types/color'

interface Props {
  type?: string
  name: string
  subjectKey: string
}

export const ListSubject: FC<Props> = ({
  type,
  name,
  subjectKey,
}) => {
  const router = useRouter()
  return (
    <li className="listSubject" key={subjectKey}>
      <p className="listSubjectType">{type}</p>
      <h1
        onClick={() =>
          router.push({
            pathname: '/subjects/[key]',
            query: {
              key: subjectKey,
            },
          })
        }
        className="listSubjectName"
      >
        {name}
      </h1>
      <Styles />
    </li>
  )
}

const Styles = () => (
  <style jsx global>
    {`
      .listSubject {
        background: ${LeadingColor};
        height: 175px;
        min-height: 175px;
        min-width: 250px;
        width: 250px;
        list-style: none;
        border-radius: 12px;
        margin-left: 30px;
        margin-top: 30px;
        padding: 0 15px;

        box-shadow: 0 2.8px 2.2px rgba(0, 0, 0, 0.034),
          0 6.7px 5.3px rgba(0, 0, 0, 0.048),
          0 12.5px 10px rgba(0, 0, 0, 0.06),
          0 22.3px 17.9px rgba(0, 0, 0, 0.072),
          0 22.8px 15.4px rgba(0, 0, 0, 0.086),
          0 25px 20px rgba(0, 0, 0, 0.12);
        transition: 0.5s;
      }

      .listSubject:hover {
        transform: scale(1.05);
      }

      .listSubjectType {
        font-family: 'Source Sans Pro', sans-serif;
        font-size: 14px;

        margin-top: 15px;
        color: ${AppBackgroundColor};
      }

      .listSubjectName {
        font-family: 'Source Sans Pro', sans-serif;
        font-size: 22px;

        margin-top: 1px;
        color: ${DefaultButtonContrastColor};
      }

      .listSubjectName:hover {
        text-decoration: underline;
        cursor: pointer;
      }
    `}
  </style>
)
